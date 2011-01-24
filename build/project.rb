require 'fileutils'

class Project
  attr_reader :name 
  attr_reader :startup_dir 
  attr_reader :startup_config
  attr_reader :startup_extension

  class << self
    def name
      @name = "nothinbutdotnetprep"
    end

    def startup_dir
      @startup_dir = "artifacts"
    end

    def specs_dir
      @specs_dir = "artifacts/specs"
    end

    def report_folder
      @report_folder = File.join(@specs_dir,'report')
    end

    def spec_assemblies
      @spec_assemblies = Dir.glob(File.join('artifacts',"nothin*specs.dll"))
    end

    def startup_extension
      @startup_extension = ".dll"
    end

  end
end
